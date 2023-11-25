﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;
namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class VaccinationController : ControllerBase
{
    [HttpGet]
    [ActionName("read")]
    public async Task<IActionResult> Read(int id)
    {
        return Ok((VaccinationViewModel)VaccinationRepository.Read(id));
    }
    
    [HttpPost]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] VaccinationViewModel newVaccination) =>
        Ok(VaccinationRepository.Create(newVaccination));
    
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List()
    { 
        var list = VaccinationRepository.List();
        var result = new List<VaccinationViewModel>();

        foreach (var entities in list)
        {
            result.Add(entities);
        }
        
        return Ok(result);
    }
    
    [HttpPut] 
    [ActionName("update")]
    public async Task<IActionResult> Update([FromBody] VaccinationViewModel model) => 
        Ok((VaccinationViewModel)VaccinationRepository.Update(model));
    
    [HttpDelete] 
    [ActionName("delete")]
    public async Task<IActionResult> Delete(int id) => 
        Ok(VaccinationRepository.Delete(id));
}