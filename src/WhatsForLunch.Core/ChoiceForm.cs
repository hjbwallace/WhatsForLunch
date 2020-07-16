using System.ComponentModel.DataAnnotations;

namespace WhatsForLunch.Core
{
    public class ChoiceForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public int? Weighting { get; set; }
    }
}