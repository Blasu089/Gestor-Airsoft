using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{
    public class ArmaEntityTypeConfiguration : IEntityTypeConfiguration<Arma>
    {
        public void Configure(EntityTypeBuilder<Arma> builder)
        {
            builder.HasKey(a => a.Cod_Referencia);
            builder.Property(a => a.Modelo).IsRequired().HasMaxLength(50);
            builder.Property(a=>a.Serie).IsRequired().HasMaxLength(50);
            builder.Property(a=>a.Marca).IsRequired().HasMaxLength(50);
            builder.Property(a=>a.Material).HasMaxLength(50);
            builder.Property(a=>a.HopUp).IsRequired().HasDefaultValue(false);
            builder.Property(a => a.Longitud);
            builder.Property(a=>a.Peso).IsRequired();
            builder.Property(a=>a.Potencia).IsRequired();
            builder.Property(a=>a.Velocidad).IsRequired();
            builder.Property(a => a.Capacidad_Cargador);
            builder.Property(a => a.Precio).IsRequired();
            builder.Property(a=>a.Foto);

            builder.HasMany(a => a.Colores)
                   .WithMany(c => c.Armas);

            builder.HasDiscriminator<string>("Tipo Arma")
                   .HasValue<Arma>("Arma")
                   .HasValue<Escopeta>("Escopeta")
                   .HasValue<Fusil>("Fusil")
                   .HasValue<Francotirador>("Francotirador")
                   .HasValue<Pistola>("Pistola");

        }
    }
}
