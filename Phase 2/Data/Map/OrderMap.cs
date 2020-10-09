namespace Pezza.DataAccess.Map
{
    using Microsoft.EntityFrameworkCore;
    using Pezza.Common.Entities;

    public partial class OrderMap
        : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            // table
            builder.ToTable("Order", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("int");

            builder.Property(t => t.RestaurantId)
                .IsRequired()
                .HasColumnName("RestaurantId")
                .HasColumnType("int");

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnName("Amount")
                .HasColumnType("decimal(17, 2)");

            builder.Property(t => t.DateCreated)
                .IsRequired()
                .HasColumnName("DateCreated")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            // relationships
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Order_Customer");

            builder.HasOne(t => t.Restaurant)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK_Order_Restaurant");
        }

    }
}
