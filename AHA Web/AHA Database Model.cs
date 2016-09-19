namespace AHA_Web
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AHA_Database_Model : DbContext
    {
        public AHA_Database_Model()
            : base("name=AHADatabaseModel")
        {
        }

        public virtual DbSet<Account_Link> Account_Link { get; set; }
        public virtual DbSet<AdelanteStaff> AdelanteStaffs { get; set; }
        public virtual DbSet<AssignedRole> AssignedRoles { get; set; }
        public virtual DbSet<BoardMember> BoardMembers { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<DonorContact> DonorContacts { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<DonorsAttendence> DonorsAttendences { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Grantor> Grantors { get; set; }
        public virtual DbSet<Grant> Grants { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolAttended> SchoolAttendeds { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAttendence> StudentAttendences { get; set; }
        public virtual DbSet<StudentFamily> StudentFamilies { get; set; }
        public virtual DbSet<User_Acct> User_Acct { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<VolunteerHistory> VolunteerHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account_Link>()
                .Property(e => e.Account_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account_Link>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Link>()
                .Property(e => e.Approved_By)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Link>()
                .Property(e => e.Account_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Staff_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.First_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Middle_Initial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Last_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdelanteStaff>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.AdelanteStaff)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdelanteStaff>()
                .HasMany(e => e.DonorContacts)
                .WithRequired(e => e.AdelanteStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdelanteStaff>()
                .HasMany(e => e.AssignedRoles)
                .WithRequired(e => e.AdelanteStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AssignedRole>()
                .Property(e => e.Staff_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AssignedRole>()
                .Property(e => e.Role_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.BM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.First_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Middle_Initial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Last_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .Property(e => e.Affiliated_Organization)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoardMember>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.BoardMember)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donation>()
                .Property(e => e.Transaction_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donation>()
                .Property(e => e.Donor_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Donation>()
                .Property(e => e.Donation_Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Donation>()
                .Property(e => e.Transaction_ID_From_Provider)
                .IsUnicode(false);

            modelBuilder.Entity<DonorContact>()
                .Property(e => e.Donor_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DonorContact>()
                .Property(e => e.Staff_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DonorContact>()
                .Property(e => e.Method_Of_Contact)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Donor_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.First_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Middle_Initial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Last_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.Donor)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.Donations)
                .WithRequired(e => e.Donor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.DonorContacts)
                .WithRequired(e => e.Donor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.DonorsAttendences)
                .WithRequired(e => e.Donor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonorsAttendence>()
                .Property(e => e.Donor_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DonorsAttendence>()
                .Property(e => e.Event_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Event_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Event_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Attendence_Cost)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Event>()
                .Property(e => e.Event_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.DonorsAttendences)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.VolunteerHistories)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.StudentAttendences)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.Grantor_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.Organization)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grantor>()
                .HasMany(e => e.Grants)
                .WithRequired(e => e.Grantor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Grant_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Grantor_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Grant_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Grant_Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Grant_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Grant_status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Grant>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Parent_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.First_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Middle_Initial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Last_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.Parent)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parent>()
                .HasMany(e => e.StudentFamilies)
                .WithRequired(e => e.Parent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Role_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Role_Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.AssignedRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<School>()
                .Property(e => e.School_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.School_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.SchoolAttendeds)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SchoolAttended>()
                .Property(e => e.Student_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttended>()
                .Property(e => e.School_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Student_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.First_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Middle_Initial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Last_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.SchoolAttendeds)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentAttendences)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentFamilies)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentAttendence>()
                .Property(e => e.Student_ID)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAttendence>()
                .Property(e => e.Event_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StudentFamily>()
                .Property(e => e.Student_ID)
                .IsUnicode(false);

            modelBuilder.Entity<StudentFamily>()
                .Property(e => e.Parent_ID)
                .IsUnicode(false);

            modelBuilder.Entity<StudentFamily>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User_Acct>()
                .Property(e => e.Account_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User_Acct>()
                .Property(e => e.UserName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User_Acct>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User_Acct>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User_Acct>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.User_Acct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Volunteer_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.First_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Middle_Initial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Last_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Address)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Zip_Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .HasMany(e => e.Account_Link)
                .WithRequired(e => e.Volunteer)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Volunteer>()
                .HasMany(e => e.VolunteerHistories)
                .WithRequired(e => e.Volunteer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VolunteerHistory>()
                .Property(e => e.Volunteer_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerHistory>()
                .Property(e => e.Event_ID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
