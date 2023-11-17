using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Model;

public partial class AcnurContext : DbContext
{
    public AcnurContext()
    {
    }

    public AcnurContext(DbContextOptions<AcnurContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alimento> Alimentos { get; set; }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<CuotaSocio> CuotaSocios { get; set; }

    public virtual DbSet<Cuotum> Cuota { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<EnvioAlimento> EnvioAlimentos { get; set; }

    public virtual DbSet<EnvioHumanitario> EnvioHumanitarios { get; set; }

    public virtual DbSet<EnvioMedicina> EnvioMedicinas { get; set; }

    public virtual DbSet<EnvioSede> EnvioSedes { get; set; }

    public virtual DbSet<InventarioAlimento> InventarioAlimentos { get; set; }

    public virtual DbSet<InventarioMedicina> InventarioMedicinas { get; set; }

    public virtual DbSet<Medicina> Medicinas { get; set; }

    public virtual DbSet<Profesion> Profesions { get; set; }

    public virtual DbSet<ProfesionVoluntario> ProfesionVoluntarios { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    public virtual DbSet<VoluntarioAdministrador> VoluntarioAdministradors { get; set; }

    public virtual DbSet<VoluntarioSanitario> VoluntarioSanitarios { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alimento>(entity =>
        {
            entity.HasKey(e => e.IdAlimento).HasName("PK__Alimento__22E89F9D5830465E");

            entity.ToTable("Alimento");

            entity.Property(e => e.IdAlimento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Id_Alimento");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.NombreAlimento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnName("Peso");
            entity.Property(e => e.Unidad).HasColumnName("Unidad");
        });

        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.IdAlmacen).HasName("PK__Almacen__1E9C729E2978E525");

            entity.ToTable("Almacen");

            entity.Property(e => e.IdAlmacen)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Id_Almacen");
            entity.Property(e => e.DescripcionAlmacen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreAlmacen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SedeId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Sede_Id");

            entity.HasOne(d => d.Sede).WithMany(p => p.Almacens)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Almacen__Sede_Id__628FA481");
        });

        modelBuilder.Entity<CuotaSocio>(entity =>
        {
            entity.HasKey(e => e.IdCuotaSocio).HasName("PK__Cuota_So__402DA5C098FB0680");

            entity.ToTable("Cuota_Socio");

            entity.Property(e => e.IdCuotaSocio).HasColumnName("Id_Cuota_Socio");
            entity.Property(e => e.CuotaId).HasColumnName("Cuota_Id");
            entity.Property(e => e.FechaPago)
                .HasColumnType("date")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.SocioId).HasColumnName("Socio_Id");

            entity.HasOne(d => d.Cuota).WithMany(p => p.CuotaSocios)
                .HasForeignKey(d => d.CuotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuota_Soc__Cuota__47DBAE45");

            entity.HasOne(d => d.Socio).WithMany(p => p.CuotaSocios)
                .HasForeignKey(d => d.SocioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuota_Soc__Socio__48CFD27E");
        });

        modelBuilder.Entity<Cuotum>(entity =>
        {
            entity.HasKey(e => e.IdCuota).HasName("PK__Cuota__AE25C03F8570703E");

            entity.Property(e => e.IdCuota)
                .ValueGeneratedNever()
                .HasColumnName("Id_Cuota");
            entity.Property(e => e.CargosAnuales)
                .HasColumnType("money")
                .HasColumnName("Cargos_Anuales");
            entity.Property(e => e.TipoCuota)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_Cuota");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__535FD61199D35B85");

            entity.ToTable("Direccion");

            entity.Property(e => e.IdDireccion)
                .ValueGeneratedNever()
                .HasColumnName("Id_Direccion");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DireccionExacta)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Direccion_Exacta");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.IdEnvio).HasName("PK__Envio__3A838833028F2F8B");

            entity.ToTable("Envio");

            entity.Property(e => e.IdEnvio).HasColumnName("Id_Envio");
            entity.Property(e => e.Destino)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaEnvio)
                .HasColumnType("date")
                .HasColumnName("Fecha_envio");
            entity.Property(e => e.TipoAyuda)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipoAyuda");
            entity.Property(e => e.UnidadMedidaId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("UnidadMedida_Id");

            entity.HasOne(d => d.UnidadMedida).WithMany(p => p.Envios)
                .HasForeignKey(d => d.UnidadMedidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio__UnidadMed__5812160E");
        });

        modelBuilder.Entity<EnvioAlimento>(entity =>
        {
            entity.HasKey(e => e.IdEnvioAlimento).HasName("PK__Envio_Al__695637860E4D1377");

            entity.ToTable("Envio_Alimento");

            entity.Property(e => e.IdEnvioAlimento).HasColumnName("Id_Envio_Alimento");
            entity.Property(e => e.AlimentoId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Alimento_Id");
            entity.Property(e => e.CantidadAlimento).HasColumnName("Cantidad_Alimento");
            entity.Property(e => e.EnvioId).HasColumnName("Envio_Id");

            entity.HasOne(d => d.Alimento).WithMany(p => p.EnvioAlimentos)
                .HasForeignKey(d => d.AlimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Ali__Alime__70DDC3D8");

            entity.HasOne(d => d.Envio).WithMany(p => p.EnvioAlimentos)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Ali__Envio__71D1E811");
        });

        modelBuilder.Entity<EnvioHumanitario>(entity =>
        {
            entity.HasKey(e => e.IdEnvioHumanitario).HasName("PK__Envio_Hu__D0CE39697BEAF8C2");

            entity.ToTable("Envio_Humanitario");

            entity.Property(e => e.IdEnvioHumanitario).HasColumnName("Id_Envio_Humanitario");
            entity.Property(e => e.EnvioId).HasColumnName("Envio_Id");
            entity.Property(e => e.VoluntarioSanitarioId).HasColumnName("Voluntario_Sanitario_Id");

            entity.HasOne(d => d.Envio).WithMany(p => p.EnvioHumanitarios)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Hum__Envio__5FB337D6");

            entity.HasOne(d => d.VoluntarioSanitario).WithMany(p => p.EnvioHumanitarios)
                .HasForeignKey(d => d.VoluntarioSanitarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Hum__Volun__5EBF139D");
        });

        modelBuilder.Entity<EnvioMedicina>(entity =>
        {
            entity.HasKey(e => e.IdEnvioMedicina).HasName("PK__Envio_Me__8C15B7793150C899");

            entity.ToTable("Envio_Medicina");

            entity.Property(e => e.IdEnvioMedicina).HasColumnName("Id_Envio_Medicina");
            entity.Property(e => e.CantidadMedicina).HasColumnName("Cantidad_Medicina");
            entity.Property(e => e.EnvioId).HasColumnName("Envio_Id");
            entity.Property(e => e.MedicinaId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Medicina_Id");

            entity.HasOne(d => d.Envio).WithMany(p => p.EnvioMedicinas)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Med__Envio__75A278F5");

            entity.HasOne(d => d.Medicina).WithMany(p => p.EnvioMedicinas)
                .HasForeignKey(d => d.MedicinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Med__Medic__74AE54BC");
        });

        modelBuilder.Entity<EnvioSede>(entity =>
        {
            entity.HasKey(e => e.IdEnvioSede).HasName("PK__Envio_Se__E4F154D61C586A49");

            entity.ToTable("Envio_Sede");

            entity.Property(e => e.IdEnvioSede).HasColumnName("Id_Envio_Sede");
            entity.Property(e => e.EnvioId).HasColumnName("Envio_Id");
            entity.Property(e => e.SedeId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Sede_Id");

            entity.HasOne(d => d.Envio).WithMany(p => p.EnvioSedes)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Sed__Envio__5BE2A6F2");

            entity.HasOne(d => d.Sede).WithMany(p => p.EnvioSedes)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Sed__Sede___5AEE82B9");
        });

        modelBuilder.Entity<InventarioAlimento>(entity =>
        {
            entity.HasKey(e => e.IdInventarioAlimento).HasName("PK__Inventar__298C093300261F44");

            entity.ToTable("Inventario_Alimento");

            entity.Property(e => e.IdInventarioAlimento).HasColumnName("Id_Inventario_Alimento");
            entity.Property(e => e.AlimentoId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Alimento_Id");
            entity.Property(e => e.AlmacenId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Almacen_Id");

            entity.HasOne(d => d.Alimento).WithMany(p => p.InventarioAlimentos)
                .HasForeignKey(d => d.AlimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Alime__693CA210");

            entity.HasOne(d => d.Almacen).WithMany(p => p.InventarioAlimentos)
                .HasForeignKey(d => d.AlmacenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Almac__6A30C649");
        });

        modelBuilder.Entity<InventarioMedicina>(entity =>
        {
            entity.HasKey(e => e.IdInventarioMedicina).HasName("PK__Inventar__492481912C35376A");

            entity.ToTable("Inventario_Medicina");

            entity.Property(e => e.IdInventarioMedicina).HasColumnName("Id_Inventario_Medicina");
            entity.Property(e => e.AlmacenId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Almacen_Id");
            entity.Property(e => e.MedicinaId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Medicina_Id");

            entity.HasOne(d => d.Almacen).WithMany(p => p.InventarioMedicinas)
                .HasForeignKey(d => d.AlmacenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Almac__6E01572D");

            entity.HasOne(d => d.Medicina).WithMany(p => p.InventarioMedicinas)
                .HasForeignKey(d => d.MedicinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Medic__6D0D32F4");
        });

        modelBuilder.Entity<Medicina>(entity =>
        {
            entity.HasKey(e => e.IdMedicina).HasName("PK__Medicina__D4176A7714E6A33C");

            entity.ToTable("Medicina");

            entity.Property(e => e.IdMedicina)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Id_Medicina");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.NombreMedicina)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Profesion>(entity =>
        {
            entity.HasKey(e => e.IdProfesion).HasName("PK__Profesio__1632DD8A148DBADE");

            entity.ToTable("Profesion");

            entity.Property(e => e.IdProfesion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Id_Profesion");
            entity.Property(e => e.NombreProfesion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProfesionVoluntario>(entity =>
        {
            entity.HasKey(e => e.IdProfesionVoluntario).HasName("PK__Profesio__AA37818B62D82B49");

            entity.ToTable("Profesion_Voluntario");

            entity.Property(e => e.IdProfesionVoluntario).HasColumnName("Id_Profesion_Voluntario");
            entity.Property(e => e.ProfesionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Profesion_Id");
            entity.Property(e => e.VoluntarioSanitarioId).HasColumnName("Voluntario_Sanitario_Id");

            entity.HasOne(d => d.Profesion).WithMany(p => p.ProfesionVoluntarios)
                .HasForeignKey(d => d.ProfesionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profesion__Profe__5165187F");

            entity.HasOne(d => d.VoluntarioSanitario).WithMany(p => p.ProfesionVoluntarios)
                .HasForeignKey(d => d.VoluntarioSanitarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profesion__Volun__5070F446");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E8682CDD013");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Id_Rol");
            entity.Property(e => e.DescripcionRol)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__Sede__A3F9F16A33E536FA");

            entity.ToTable("Sede");

            entity.Property(e => e.IdSede)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Id_Sede");
            entity.Property(e => e.DireccionId).HasColumnName("Direccion_Id");

            entity.HasOne(d => d.Direccion).WithMany(p => p.Sedes)
                .HasForeignKey(d => d.DireccionId)
                .HasConstraintName("FK_Sede_Direccion");
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.IdSocio).HasName("PK__Socio__8CB15183D57259D7");

            entity.ToTable("Socio");

            entity.Property(e => e.IdSocio)
                .ValueGeneratedNever()
                .HasColumnName("Id_Socio");
            entity.Property(e => e.CuentaBanco).HasColumnName("Cuenta_Banco");
            entity.Property(e => e.CuotaId).HasColumnName("Cuota_Id");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.Cuota).WithMany(p => p.Socios)
                .HasForeignKey(d => d.CuotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Socio__Cuota_Id__44FF419A");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.Socios)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Socio__Usuario_D__440B1D61");
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida).HasName("PK__UnidadMe__5BD46EDD38B5BB47");

            entity.Property(e => e.IdUnidadMedida)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Id_UnidadMedida");
            entity.Property(e => e.Unidad)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.DniUsuario).HasName("PK__Usuario__25A9C8D8DE828C07");

            entity.ToTable("Usuario");

            entity.Property(e => e.DniUsuario)
                .ValueGeneratedNever()
                .HasColumnName("Dni_Usuario");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Apellido2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Clave).HasMaxLength(8000);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.SedeId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Sede_Id");

            entity.HasOne(d => d.Sede).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Sede");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol).HasName("PK__Usuario___1BAC97A7291E7323");

            entity.ToTable("Usuario_Rol");

            entity.Property(e => e.IdUsuarioRol).HasColumnName("Id_Usuario_Rol");
            entity.Property(e => e.RolId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rol_Id");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario_R__Rol_I__3C69FB99");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario_R__Usuar__3B75D760");
        });

        modelBuilder.Entity<VoluntarioAdministrador>(entity =>
        {
            entity.HasKey(e => e.IdVoluntarioAdministrador).HasName("PK__Voluntar__41D71E791967A4A1");

            entity.ToTable("Voluntario_Administrador");

            entity.Property(e => e.IdVoluntarioAdministrador)
                .ValueGeneratedNever()
                .HasColumnName("Id_Voluntario_Administrador");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.VoluntarioAdministradors)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voluntari__Usuar__3F466844");
        });

        modelBuilder.Entity<VoluntarioSanitario>(entity =>
        {
            entity.HasKey(e => e.IdVoluntarioSanitario).HasName("PK__Voluntar__380A198C29AC2DEE");

            entity.ToTable("Voluntario_Sanitario");

            entity.Property(e => e.IdVoluntarioSanitario)
                .ValueGeneratedNever()
                .HasColumnName("Id_Voluntario_Sanitario");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.VoluntarioSanitarios)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voluntari__Usuar__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
