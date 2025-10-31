using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zkooWebserver.EF;
using zkooWebserver.Models;
using zkooWebserver.ViewModels;
using zkooWebserver.ViewModels.Appointments;

namespace zkooWebserver.Controllers
{
    public class ManagementController : Controller
    {
        DatabaseZkooContext _context;
        public ManagementController(DatabaseZkooContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            AppointmentsViewModel viewModel = new()
            {
                Appointments = _context.Appointment.ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var appointment = _context.Appointment.Select(m => m.AppointmentId == id);
            if (appointment is null)
                return NotFound();

            DetailsViewModel viewModel = new() { Appointment = (Appointment)appointment };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = _context.Appointment.Select(m => m.AppointmentId == id);
            if (appointment is null)
                return NotFound();

            EditViewModel viewModel = new() { Appointment = (Appointment)appointment };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Appointment? toChange = _context.Appointment.Select(x => x == model.Appointment) as Appointment;

            if (toChange is null)
                return NotFound();

            toChange.Patient = model.Appointment.Patient;
            toChange.Doctor = model.Appointment.Doctor;
            toChange.Date = model.Appointment.Date;
            _context.Attach(toChange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Appointment.Any(x => x == model.Appointment))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (!ModelState.IsValid || !model.Appointment.IsValid())
                return View(model);

            Appointment appointment = new()
            {
                Patient = model.Appointment.Patient,
                Doctor = model.Appointment.Doctor,
                Date = model.Appointment.Date
            };

            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var appointment = _context.Appointment.Select(m => m.AppointmentId == id);
            if (appointment is null)
                return NotFound();

            DeleteViewModel viewModel = new() { Appointment = (Appointment)appointment };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var appointment = _context.Appointment.Select(x => x.AppointmentId == id);
            if (appointment is not null)
            {
                _context.Appointment.Remove((Appointment)appointment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
