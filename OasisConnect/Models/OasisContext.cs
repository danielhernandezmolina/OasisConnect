using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OasisConnect.Models;

public partial class OasisContext : DbContext
{
    public OasisContext()
    {
    }

    public OasisContext(DbContextOptions<OasisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Hamaca> Hamacas { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PRIMARY");

            entity.ToTable("detalle_pedidos");

            entity.HasIndex(e => e.IdPedidos, "fk_detalle_pedido_idx");

            entity.HasIndex(e => e.IdProductos, "fk_detalle_producto_idx");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdPedidos).HasColumnName("id_pedidos");
            entity.Property(e => e.IdProductos).HasColumnName("id_productos");
            entity.Property(e => e.Notas)
                .HasMaxLength(45)
                .HasColumnName("notas");

            entity.HasOne(d => d.IdPedidosNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_pedido");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_producto");
        });

        modelBuilder.Entity<Hamaca>(entity =>
        {
            entity.HasKey(e => e.IdHamacas).HasName("PRIMARY");

            entity.ToTable("hamacas");

            entity.HasIndex(e => e.IdHotel, "fk_hamacas_hotel_idx");

            entity.HasIndex(e => new { e.IdZona, e.IdHotel }, "fk_hamacas_zona_compuesta_idx");

            entity.HasIndex(e => e.IdZona, "fk_hamacas_zona_idx");

            entity.Property(e => e.IdHamacas)
                .ValueGeneratedNever()
                .HasColumnName("id_hamacas");
            entity.Property(e => e.IdHotel).HasColumnName("id_hotel");
            entity.Property(e => e.IdZona).HasColumnName("id_zona");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(25)
                .HasColumnName("identificacion");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Hamacas)
                .HasForeignKey(d => d.IdHotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hamacas_hotel");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.Hamacas)
                .HasForeignKey(d => d.IdZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hamacas_zona");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PRIMARY");

            entity.ToTable("hotel");

            entity.Property(e => e.IdHotel).HasColumnName("id_hotel");
            entity.Property(e => e.Cif)
                .HasMaxLength(20)
                .HasColumnName("cif");
            entity.Property(e => e.ConfigPmsEndpoint)
                .HasMaxLength(255)
                .HasColumnName("config_pms_endpoint");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.EstadoActividad)
                .HasDefaultValueSql("'1'")
                .HasColumnName("estado_actividad");
            entity.Property(e => e.NombreHotel)
                .HasMaxLength(150)
                .HasColumnName("nombre_hotel");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedidos).HasName("PRIMARY");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.IdHamacas, "fk_pedidos_hamacas_idx");

            entity.Property(e => e.IdPedidos)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_pedidos");
            entity.Property(e => e.ApellidoHuesped)
                .HasMaxLength(20)
                .HasColumnName("apellido_huesped");
            entity.Property(e => e.Estado)
                .HasColumnType("enum('Pendiente','Recibido','Procesando','Entregado','Pagado','Cancelado')")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.IdHamacas).HasColumnName("id_hamacas");
            entity.Property(e => e.MetodoPago)
                .HasColumnType("enum('Efectivo','Tarjeta','Habitacion','Pasarela QR')")
                .HasColumnName("metodo_pago");
            entity.Property(e => e.NumHabitacion).HasColumnName("num_habitacion");
            entity.Property(e => e.Total)
                .HasPrecision(8, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdHamacasNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdHamacas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedidos_hamacas");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.Property(e => e.IdProductos)
                .ValueGeneratedNever()
                .HasColumnName("id_productos");
            entity.Property(e => e.Alergenos)
                .HasMaxLength(45)
                .HasColumnName("alergenos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(8, 2)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.IdZona).HasName("PRIMARY");

            entity.ToTable("zona");

            entity.HasIndex(e => e.IdHotel, "fk_zona_hotel_idx");

            entity.Property(e => e.IdZona)
                .ValueGeneratedNever()
                .HasColumnName("id_zona");
            entity.Property(e => e.IdHotel).HasColumnName("id_hotel");
            entity.Property(e => e.NombreZona)
                .HasMaxLength(45)
                .HasColumnName("nombre_zona");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Zonas)
                .HasForeignKey(d => d.IdHotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_zona_hotel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
