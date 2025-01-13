﻿using AEBestGatePath.Core;

namespace AEBestGatePath.Data.Entities;

public class Gate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Astro Astro { get; set; }
    public bool Occupied { get; set; } = false;
    public DateTime LastUpdated { get; set; }
}