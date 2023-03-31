using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


[Table("videogames")]
[Index(nameof(Id), IsUnique = true)]
public class Videogame
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Overview { get; set; }
    public DateTime Release_Date { get; set; }
    public long SoftwareHouseId { get; set; }
    public SoftwareHouse SoftwareHouse { get; set; }

    public override string ToString()
    {
        var nl = Environment.NewLine;
        return $"Id: {Id} {nl}" +
            $"Name: {Name} {nl}" +
            $"Overview: {Overview}{nl}" +
            $"Release date: {Release_Date}{nl}" +
            $"Software house id: {SoftwareHouseId}";
    }
}

