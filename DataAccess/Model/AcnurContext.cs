﻿using System;
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

    public virtual DbSet<RegistroAccione> RegistroAcciones { get; set; }

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
            entity.HasKey(e => e.IdAlimento).HasName("PK__Alimento__22E89F9D83CF17B2");

            entity.ToTable("Alimento", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Alimento");
                    tb.HasTrigger("Trigger_Eliminacion_Alimento");
                    tb.HasTrigger("Trigger_Insercion_Alimento");
                });

            entity.Property(e => e.IdAlimento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Id_Alimento");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.NombreAlimento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unidad)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.IdAlmacen).HasName("PK__Almacen__1E9C729E649D2327");

            entity.ToTable("Almacen", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Almacen");
                    tb.HasTrigger("Trigger_Eliminacion_Almacen");
                    tb.HasTrigger("Trigger_Insercion_Almacen");
                });

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
                .HasConstraintName("FK__Almacen__Sede_Id__74AE54BC");
        });

        modelBuilder.Entity<CuotaSocio>(entity =>
        {
            entity.HasKey(e => e.IdCuotaSocio).HasName("PK__Cuota_So__402DA5C0711B6CE5");

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
                .HasConstraintName("FK__Cuota_Soc__Cuota__59FA5E80");

            entity.HasOne(d => d.Socio).WithMany(p => p.CuotaSocios)
                .HasForeignKey(d => d.SocioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuota_Soc__Socio__5AEE82B9");
        });

        modelBuilder.Entity<Cuotum>(entity =>
        {
            entity.HasKey(e => e.IdCuota).HasName("PK__Cuota__AE25C03F196FE531");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Cuota");
                    tb.HasTrigger("Trigger_Eliminacion_Cuota");
                    tb.HasTrigger("Trigger_Insercion_Cuota");
                });

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
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__535FD6115CA1999F");

            entity.ToTable("Direccion", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Direccion");
                    tb.HasTrigger("Trigger_Eliminacion_Direccion");
                    tb.HasTrigger("Trigger_Insercion_Direccion");
                });

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
            entity.HasKey(e => e.IdEnvio).HasName("PK__Envio__3A838833A31F4643");

            entity.ToTable("Envio", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Envio");
                    tb.HasTrigger("Trigger_Eliminacion_Envio");
                    tb.HasTrigger("Trigger_Insercion_Envio");
                });

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
                .HasConstraintName("FK__Envio__UnidadMed__6A30C649");
        });

        modelBuilder.Entity<EnvioAlimento>(entity =>
        {
            entity.HasKey(e => e.IdEnvioAlimento).HasName("PK__Envio_Al__69563786A57E620E");

            entity.ToTable("Envio_Alimento", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Envio_Alimento");
                    tb.HasTrigger("Trigger_Actualizar_InventarioAlimento");
                    tb.HasTrigger("Trigger_Eliminacion_Envio_Alimento");
                    tb.HasTrigger("Trigger_Insercion_Envio_Alimento");
                });

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
                .HasConstraintName("FK__Envio_Ali__Alime__02FC7413");

            entity.HasOne(d => d.Envio).WithMany(p => p.EnvioAlimentos)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Ali__Envio__03F0984C");
        });

        modelBuilder.Entity<EnvioHumanitario>(entity =>
        {
            entity.HasKey(e => e.IdEnvioHumanitario).HasName("PK__Envio_Hu__D0CE39694B8EF4E1");

            entity.ToTable("Envio_Humanitario", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizacion_Envio_Humanitario");
                    tb.HasTrigger("Trigger_CambiarEstadoVoluntario");
                    tb.HasTrigger("Trigger_Eliminacion_Envio_Humanitario");
                    tb.HasTrigger("Trigger_Insercion_Envio_Humanitario");
                });

            entity.Property(e => e.IdEnvioHumanitario).HasColumnName("Id_Envio_Humanitario");
            entity.Property(e => e.EnvioId).HasColumnName("Envio_Id");
            entity.Property(e => e.VoluntarioSanitarioId).HasColumnName("Voluntario_Sanitario_Id");

            entity.HasOne(d => d.Envio).WithMany(p => p.EnvioHumanitarios)
                .HasForeignKey(d => d.EnvioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Hum__Envio__71D1E811");

            entity.HasOne(d => d.VoluntarioSanitario).WithMany(p => p.EnvioHumanitarios)
                .HasForeignKey(d => d.VoluntarioSanitarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Hum__Volun__70DDC3D8");
        });

        modelBuilder.Entity<EnvioMedicina>(entity =>
        {
            entity.HasKey(e => e.IdEnvioMedicina).HasName("PK__Envio_Me__8C15B779E52C9156");

            entity.ToTable("Envio_Medicina", tb =>
                {
                    tb.HasTrigger("Trigger_Actualizar_InventarioMedicina");
                    tb.HasTrigger("Trigger_Delete_Envio_Medicina");
                    tb.HasTrigger("Trigger_Insert_Envio_Medicina");
                    tb.HasTrigger("Trigger_Update_Envio_Medicina");
                });

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
                .HasConstraintName("FK__Envio_Med__Envio__07C12930");

            entity.HasOne(d => d.Medicina).WithMany(p => p.EnvioMedicinas)
                .HasForeignKey(d => d.MedicinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Med__Medic__06CD04F7");
        });

        modelBuilder.Entity<EnvioSede>(entity =>
        {
            entity.HasKey(e => e.IdEnvioSede).HasName("PK__Envio_Se__E4F154D64EDF1516");

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
                .HasConstraintName("FK__Envio_Sed__Envio__6E01572D");

            entity.HasOne(d => d.Sede).WithMany(p => p.EnvioSedes)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envio_Sed__Sede___6D0D32F4");
        });

        modelBuilder.Entity<InventarioAlimento>(entity =>
        {
            entity.HasKey(e => e.IdInventarioAlimento).HasName("PK__Inventar__298C0933AD6773AE");

            entity.ToTable("Inventario_Alimento", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Inventario_Alimento");
                    tb.HasTrigger("Trigger_Insert_Inventario_Alimento");
                    tb.HasTrigger("Trigger_Update_Inventario_Alimento");
                });

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
                .HasConstraintName("FK__Inventari__Alime__7B5B524B");

            entity.HasOne(d => d.Almacen).WithMany(p => p.InventarioAlimentos)
                .HasForeignKey(d => d.AlmacenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Almac__7C4F7684");
        });

        modelBuilder.Entity<InventarioMedicina>(entity =>
        {
            entity.HasKey(e => e.IdInventarioMedicina).HasName("PK__Inventar__49248191F05E2A65");

            entity.ToTable("Inventario_Medicina", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Inventario_Medicina");
                    tb.HasTrigger("Trigger_Insert_Inventario_Medicina");
                    tb.HasTrigger("Trigger_Update_Inventario_Medicina");
                });

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
                .HasConstraintName("FK__Inventari__Almac__00200768");

            entity.HasOne(d => d.Medicina).WithMany(p => p.InventarioMedicinas)
                .HasForeignKey(d => d.MedicinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Medic__7F2BE32F");
        });

        modelBuilder.Entity<Medicina>(entity =>
        {
            entity.HasKey(e => e.IdMedicina).HasName("PK__Medicina__D4176A77691A0A54");

            entity.ToTable("Medicina", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Medicina");
                    tb.HasTrigger("Trigger_Insert_Medicina");
                    tb.HasTrigger("Trigger_Update_Medicina");
                });

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
            entity.HasKey(e => e.IdProfesion).HasName("PK__Profesio__1632DD8A8D7BBCB5");

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
            entity.HasKey(e => e.IdProfesionVoluntario).HasName("PK__Profesio__AA37818BADA5BF1B");

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
                .HasConstraintName("FK__Profesion__Profe__6383C8BA");

            entity.HasOne(d => d.VoluntarioSanitario).WithMany(p => p.ProfesionVoluntarios)
                .HasForeignKey(d => d.VoluntarioSanitarioId)
                .HasConstraintName("FK__Profesion__Volun__628FA481");
        });

        modelBuilder.Entity<RegistroAccione>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Registro__7FD13FA0EF4EC885");

            entity.Property(e => e.Accion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Campo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Pc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PC");
            entity.Property(e => e.Tabla)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E86648AADA3");

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
            entity.HasKey(e => e.IdSede).HasName("PK__Sede__A3F9F16AC1672F6D");

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
            entity.HasKey(e => e.IdSocio).HasName("PK__Socio__8CB15183BED05E24");

            entity.ToTable("Socio", tb =>
                {
                    tb.HasTrigger("ActualizarCuotaSocio");
                    tb.HasTrigger("Trigger_Delete_Socio");
                    tb.HasTrigger("Trigger_Insert_Socio");
                    tb.HasTrigger("Trigger_Update_Socio");
                });

            entity.Property(e => e.IdSocio)
                .ValueGeneratedNever()
                .HasColumnName("Id_Socio");
            entity.Property(e => e.CuentaBanco).HasColumnName("Cuenta_Banco");
            entity.Property(e => e.CuotaId).HasColumnName("Cuota_Id");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.Cuota).WithMany(p => p.Socios)
                .HasForeignKey(d => d.CuotaId)
                .HasConstraintName("FK__Socio__Cuota_Id__571DF1D5");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.Socios)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Socio__Usuario_D__5629CD9C");
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida).HasName("PK__UnidadMe__5BD46EDDDD02CC94");

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
            entity.HasKey(e => e.DniUsuario).HasName("PK__Usuario__25A9C8D854697335");

            entity.ToTable("Usuario", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Usuario");
                    tb.HasTrigger("Trigger_Insert_Usuario");
                    tb.HasTrigger("Trigger_Update_Usuario");
                });

            entity.Property(e => e.DniUsuario)
                .ValueGeneratedNever()
                .HasColumnName("Dni_Usuario");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Apellido2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(8000)
                .IsUnicode(false);
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
            entity.HasKey(e => e.IdUsuarioRol).HasName("PK__Usuario___1BAC97A75D4FD21B");

            entity.ToTable("Usuario_Rol", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Usuario_Rol");
                    tb.HasTrigger("Trigger_Insert_Usuario_Rol");
                });

            entity.Property(e => e.IdUsuarioRol).HasColumnName("Id_Usuario_Rol");
            entity.Property(e => e.RolId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rol_Id");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario_R__Rol_I__4E88ABD4");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario_R__Usuar__4D94879B");
        });

        modelBuilder.Entity<VoluntarioAdministrador>(entity =>
        {
            entity.HasKey(e => e.IdVoluntarioAdministrador).HasName("PK__Voluntar__41D71E7927D79BDA");

            entity.ToTable("Voluntario_Administrador", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Voluntario_Administrador");
                    tb.HasTrigger("Trigger_Insert_Voluntario_Administrador");
                });

            entity.Property(e => e.IdVoluntarioAdministrador)
                .ValueGeneratedNever()
                .HasColumnName("Id_Voluntario_Administrador");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.VoluntarioAdministradors)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voluntari__Usuar__5165187F");
        });

        modelBuilder.Entity<VoluntarioSanitario>(entity =>
        {
            entity.HasKey(e => e.IdVoluntarioSanitario).HasName("PK__Voluntar__380A198C9B076CD6");

            entity.ToTable("Voluntario_Sanitario", tb =>
                {
                    tb.HasTrigger("Trigger_Delete_Voluntario_Sanitario");
                    tb.HasTrigger("Trigger_Insert_Voluntario_Sanitario");
                });

            entity.Property(e => e.IdVoluntarioSanitario)
                .ValueGeneratedNever()
                .HasColumnName("Id_Voluntario_Sanitario");
            entity.Property(e => e.UsuarioDni).HasColumnName("Usuario_Dni");

            entity.HasOne(d => d.UsuarioDniNavigation).WithMany(p => p.VoluntarioSanitarios)
                .HasForeignKey(d => d.UsuarioDni)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voluntari__Usuar__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
