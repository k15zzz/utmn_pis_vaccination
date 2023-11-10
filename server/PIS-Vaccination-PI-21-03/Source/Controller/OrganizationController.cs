﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]


public class OrganizationController : ControllerBase
{
    [HttpPost]
    [ActionName("add-organization")]
    public async Task<IActionResult> AddOrganization([FromBody] OrganizationViewModel newOrganization) =>
        Ok(new OrganizationRepository().CreateAsync(newOrganization));
    
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List() => Ok(new OrganizationRepository().ReadTableAsync());
    
    [HttpPut("{id}")] [ActionName("update-organization")]
    public async Task<IActionResult> UpdateOrganization([FromBody] JsonContent organizationModel, [FromRoute] int id)
    {
        new OrganizationRepository().UpdateAsync(id, organizationModel);
        return Ok();
    }
    [HttpPut("{id}")] [ActionName("delete-organization")]
    public async Task<IActionResult> DeleteOrganization([FromRoute] int id)
    {
        new OrganizationRepository().DeleteAsync(id);
        return Ok();
    }
}