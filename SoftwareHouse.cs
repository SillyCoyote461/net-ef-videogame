using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoftwareHouse
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public long TaxId { get; set; }
    public string? City { get; set;}
    public string? Country { get; set;}

    public IEnumerable<Videogame>? Videogames { get; set; }
}

