using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorldCities.Server.Data.Models;

[Table("Cities")]
[Index(nameof(Name))]
[Index(nameof(Lat))]
[Index(nameof(Lon))]
public class City
{
    /// <summary>
    /// The unique ID and primary key for this City
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }
    
    /// <summary>
    /// City name (in UTF8 format)
    /// </summary>
    // Required modifier: the property must be initialized via an object initializer
    public required string Name { get; set; }
    
    /// <summary>
    /// City latitude
    /// </summary>
    [Column(TypeName = "decimal(7,4)")]
    public decimal Lat  { get; set; }
    
    /// <summary>
    /// City longitude
    /// </summary>
    [Column(TypeName = "decimal(7,4)")]
    public decimal Lon { get; set; }
    
    /// <summary>
    /// Country ID (forgeign key)
    /// </summary>
    [ForeignKey(nameof(Country))] // will create a constraint to enforce this relationship
    public int CountryId { get; set; }
    
    /// <summary>
    /// The country this city exists in
    /// </summary>
    public Country? Country { get; set; }
}