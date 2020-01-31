using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetGrooming.Models.ViewModels
{
    public class UpdatePet
    {
        // info needed to update
        //info about one pet
        // info about many Species

        public Pet pet { get; set; }
        public List<Species> species { get; set; }

    }
}