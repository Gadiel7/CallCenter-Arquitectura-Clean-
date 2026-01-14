using Domain.Interfaces;
using Aplication.DTOs;

public class DashboardUseCase
{
    private readonly IContactoCallCenter _contactoRepo;
    private readonly IEstudiante _estudianteRepo;
    public DashboardUseCase(IContactoCallCenter contactoRepo, IEstudiante estudianteRepo)
    {
        _contactoRepo = contactoRepo;
        _estudianteRepo = estudianteRepo;
    }

    public async Task<DashboardMetricasDto> ObtenerMetricas()
{
    var contactos = await _contactoRepo.GetAllAsync();
    var estudiantes = await _estudianteRepo.GetAllAsync();

    var contactosDashboard = contactos.Select(c =>
    {
        var estudiante = estudiantes.FirstOrDefault(e => e.Id == c.EstudianteId);

        return new ContactoDashboardDto
        {
            Id = c.Id,
            Nombre = estudiante?.Nombre ?? "Sin nombre",
            Celular = estudiante?.Celular ?? "Sin celular",
            Contactado = c.Estado == "Contactado"
        };
    }).ToList();

    return new DashboardMetricasDto
    {
        TotalContactos = contactos.Count,
        Contactados = contactos.Count(c => c.Estado == "Contactado"),
        NoContactados = contactos.Count(c => c.Estado == "No Contactado"),
        Contactos = contactosDashboard
    };
}

}
