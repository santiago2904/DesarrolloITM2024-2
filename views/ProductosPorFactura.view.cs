using TallerDesarrollo.models;
using TallerDesarrollo.services;

namespace TallerDesarrollo.views;

private readonly ProductosPorFacturaService _productosporfacturaservice;

    public ProductosPorFacturaView()
    {
        _ProductosPorFacturaService = new PersonaService();
    }