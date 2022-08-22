using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities;

public class Review
{
    public int Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Headline is required.")]
    public string Headline { get; set; }
    [Required(ErrorMessage = "Rating is required.")]
    public int Rating { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
    public string ReviewerName { get; set; }
    [Required]
    public Movie Movie { get; set; }
    public int MovieId { get; set; }
}

public class Movie
{
    public int Id { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter a Title.")]
    public string Title { get; set; }
    public string Summary { get; set; }
    public int ReleaseYear { get; set; }
    public int BoxOfficeSumInMillions { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}