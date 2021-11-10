﻿using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class MedicationIngredientService : IMedicationIngredientService

    {
        private readonly IMedicationIngredientRepository medicationIngredientRepository;

        public MedicationIngredientService(IMedicationIngredientRepository medicationIngredientRepository)
        {
            this.medicationIngredientRepository = medicationIngredientRepository;
        }

        public List<MedicationIngredient> GetAll()
        {
            return medicationIngredientRepository.GetAll();
        }
    }
}
