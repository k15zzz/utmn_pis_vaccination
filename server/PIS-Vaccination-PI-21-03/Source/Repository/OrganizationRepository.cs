﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class OrganizationRepository : IRepository<OrganizationEntitiesModel>
{
    public int CreateAsync(OrganizationEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Organizations.AddAsync(model);
            return db.Organizations
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public Task<List<OrganizationEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationEntitiesModel> ReadItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(int id, JsonContent newModel)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.FindAsync(id); 
            if (organization != null)
            {
                var updatedOrganization =
                    JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString()); 
                context.Entry(organization).CurrentValues.SetValues(updatedOrganization);
                context.SaveChangesAsync();
            }
        }
    }

    public void DeleteAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.FindAsync(id).Result;
            if (organization != null)
            {
                context.Organizations.Remove(organization);
                context.SaveChangesAsync();
            }
            // Если не нашло, вывести сообщение об отсутствии организации
        }
    }
}