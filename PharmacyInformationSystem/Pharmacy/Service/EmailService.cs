using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Repository.TenderingRepository;

namespace PharmacyClassLib.Service
{
    public class EmailService
    {
        private readonly NetworkCredential emailCredentials;
        private readonly SmtpClient smtp;
        private readonly IRegisteredHospitalRepository registeredHospitalRepository;
        private readonly IPharmacyRepository pharmacyRepository;
        private readonly IMedicationRepository medicationRepository;

        public EmailService(IRegisteredHospitalRepository registeredHospitalRepository, IPharmacyRepository pharmacyRepository, IMedicationRepository medicationRepository)
        {
            this.registeredHospitalRepository = registeredHospitalRepository;
            this.pharmacyRepository = pharmacyRepository;
            this.medicationRepository = medicationRepository;

            emailCredentials = new NetworkCredential(Environment.GetEnvironmentVariable("EMAIL_USERNAME") ?? "psworganisation8@outlook.com", Environment.GetEnvironmentVariable("EMAIL_PASSWORD") ?? "pswFtnOrganisation8");
            smtp = new SmtpClient();
            smtp.Port = int.Parse(Environment.GetEnvironmentVariable("EMAIL_PORT") ?? "587");
            smtp.Host = Environment.GetEnvironmentVariable("EMAIL_HOST") ?? "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = this.emailCredentials;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        
        public void EmailHospitalThatMedicinesDelivered(string pharmacyName, string apiKey, long phamracyId, long medicationId, long quantity)
        {
            RegisteredHospital hospital = registeredHospitalRepository.GetByApiKey(apiKey);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.emailCredentials.UserName);
            message.To.Add(new MailAddress(hospital.EmailAddress));
            message.Subject = "Urgent procurement of medication";
            message.IsBodyHtml = true;
            message.Body = GetBodyMessage(pharmacyName, hospital, phamracyId, medicationId, quantity);

            smtp.Send(message);
        }

        private string GetBodyMessage(string pharmacyName, RegisteredHospital hospital, long phamracyId, long medicationId, long quantity)
        {
            Pharmacy pharmacy = pharmacyRepository.Get(phamracyId);
            Medication medication = medicationRepository.Get(medicationId);

            String body = "<html><body>" +
                          "<p>Hello, " + hospital.Name + "</p>" +
                          "<p>We are notificating you that your urgent procurement of medication is delivered.</p><br>" +
                          "<p>This is medication that you are ordered:</p><br>" +
                          "<p>Medication name: <strong>" + medication.Name + "</strong></p>" +
                          "<p>Quantity: <strong>" + quantity + "</strong></p>";
            
            body += "<h1>Best wishes, " + pharmacyName + "</h1>";
            body += "</body></html>";
            return body;
        }
    }
}
