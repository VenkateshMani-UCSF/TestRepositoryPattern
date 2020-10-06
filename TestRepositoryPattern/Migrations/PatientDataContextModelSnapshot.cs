﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestRepositoryPattern.Domain;

namespace TestRepositoryPattern.Migrations
{
    [DbContext(typeof(PatientDataContext))]
    partial class PatientDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestRepositoryPattern.Models.CodeVerifier", b =>
                {
                    b.Property<string>("RequestId")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.ToTable("CodeVerifiers");
                });

            modelBuilder.Entity("TestRepositoryPattern.Models.ReferralState", b =>
                {
                    b.Property<string>("ReferralId")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("FinishedOnboarding")
                        .HasColumnType("bit");

                    b.HasKey("ReferralId");

                    b.ToTable("ReferralStates");
                });
#pragma warning restore 612, 618
        }
    }
}
