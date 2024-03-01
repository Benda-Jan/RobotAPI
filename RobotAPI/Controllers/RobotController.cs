using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RobotAPI.Dtos;
using RobotAPI.Models;
using RobotAPI.Services;

namespace RobotAPI.Controllers;

/// <summary>
/// Robot controller to handle HttpRequests
/// </summary>
[ApiController]
[Route("[controller]")]
public class RobotController : Controller
{
    private readonly RobotService _service;

    /// <summary>
    /// Robot controller c'tor
    /// </summary>
    public RobotController(RobotService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retuns the item with specified Id.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create(RobotInputDto input)
    {
        RobotOutputDto result;
        try
        {
            input.Validate();
            result = _service.Simulate(input);
        }
        catch (BadHttpRequestException ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(result);
    }
}

