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
    public DateTime ReleaseDate { get; set; }
    public long HouseId { get; set; }
    public SoftwareHouse SoftwareHouse { get; set; }
}

