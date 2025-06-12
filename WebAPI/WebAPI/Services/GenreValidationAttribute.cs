using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAPI.Services
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GenreValidationAttribute : ValidationAttribute
    {
        private static readonly string[] AllowedGenres =
           { "sci-fi", "historyczny", "dramat" };

        public override bool IsValid(object? value)
        {
            if (value is not string genre) return false;
            return AllowedGenres.Contains(genre.Trim().ToLower());
        }

        public override string FormatErrorMessage(string name)
            => $"Pole {name} musi mieć wartość jedną z: Sci-Fi, historyczny, dramat.";
    }
}
