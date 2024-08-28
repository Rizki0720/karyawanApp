using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using karyawanApp.Models;
using karyawanApp.services;

namespace karyawanApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEmployeeService _employeeService;
    private readonly IAbsensi _absensi;

    public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService, IAbsensi absensi)
    {
        _logger = logger;
        _employeeService = employeeService;
        _absensi = absensi;
    }

    [HttpGet]
    public IActionResult IndexAsync()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> Employee()
    {
        var employee = await _employeeService.GetAllEmployees();
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }
    [HttpGet]
    public IActionResult AddEmploye()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(Employee employee)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.AddEmployee(employee);
            return RedirectToAction("Employee"); // Redirect ke halaman Employee setelah berhasil menambah data
        }
        return View(employee); // Tampilkan kembali form jika ada validasi yang gagal
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> EmployeeById(string id)
    {
        var employee = await _employeeService.EmployeeById(id);
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEmployee(string id)
    {
        var employee = await _employeeService.EmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }

        await _employeeService.Delete(id);
        return RedirectToAction("Employee");  // Redirect ke halaman utama setelah penghapusan
    }

    // GET: /Employee/Edit/5
    [HttpGet]
    public async Task<IActionResult> EditEmployee(string id)
    {
        var employee = await _employeeService.EmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    // POST: /Employee/Edit/5
    [HttpPost]
    public async Task<IActionResult> EditEmployee(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        await _employeeService.Update(employee);
        return RedirectToAction("Employee");
    }


    [HttpGet]
    public async Task<IActionResult> AbsensiGet()
    {
        var employee = await _absensi.GetAbsensi();
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpGet]
    public IActionResult AddAbsensi()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAbsensi(AbsensiKaryawan absensi)
    {
        if (ModelState.IsValid)
        {
            await _absensi.AddAbsensi(absensi);
            return RedirectToAction("AbsensiGet");
        }
        return View(absensi);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAbsensi(string id)
    {
        var employee = await _absensi.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }

        await _absensi.Delete(id);
        return RedirectToAction("AbsensiGet");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
