﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class ContractController : ControllerBase
{
    [HttpGet]
    [ActionName("read")]
    [CanPermission("read-contract")]
    public async Task<IActionResult> Read(int id)
    {
        return Ok((ContractViewModel)ContractRepository.Read(id));
    }
    
    [HttpPost]
    [ActionName("create")]
    [CanPermission("create-contract")]
    public async Task<IActionResult> Create([FromBody] ContractViewModel newContract)
    {
        return Ok(ContractRepository.Create(newContract));
    }
    
    [HttpGet]
    [ActionName("list")]
    [CanPermission("read-contract")]
    public async Task<IActionResult> List()
    { 
        var list = ContractRepository.ReadList();
        var result = new List<ContractViewModel>();

        foreach (var entitiesModel in list)
        {
            result.Add(entitiesModel);
        }
        
        return Ok(result);
    }
    
    [HttpPut] 
    [ActionName("update")]
    [CanPermission("update-contract")]
    public async Task<IActionResult> Update([FromBody] ContractViewModel contractModel)
    { 
        return Ok((ContractViewModel)ContractRepository.Update(contractModel));
    }
    
    [HttpDelete] 
    [ActionName("delete")]
    [CanPermission("delete-contract")]
    public async Task<IActionResult> Delete(int id)
    { 
        return Ok(ContractRepository.Delete(id));
    }
}