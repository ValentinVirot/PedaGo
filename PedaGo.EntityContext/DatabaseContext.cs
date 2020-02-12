//-----------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.EntityContext
{
    using Microsoft.EntityFrameworkCore;
    using PedaGo.Entities;

    /// <summary>
    /// Class containing the connection with the database
    /// </summary>
    public partial class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext" /> class.
        /// </summary>
        /// <param name="options">Model options</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets database set of Administrators table
        /// </summary>
        public virtual DbSet<Administrator> Administrators { get; set; }

        /// <summary>
        /// Gets or sets database set of Answers table
        /// </summary>
        public virtual DbSet<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets database set of Games table
        /// </summary>
        public virtual DbSet<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets database set of Messages table
        /// </summary>
        public virtual DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Gets or sets database set of Missions table
        /// </summary>
        public virtual DbSet<Mission> Missions { get; set; }

        /// <summary>
        /// Gets or sets database set of Organizers table
        /// </summary>
        public virtual DbSet<Organizer> Organizers { get; set; }

        /// <summary>
        /// Gets or sets database set of Plays table
        /// </summary>
        public virtual DbSet<Play> Plays { get; set; }

        /// <summary>
        /// Gets or sets database set of Players table
        /// </summary>
        public virtual DbSet<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets database set of Routes table
        /// </summary>
        public virtual DbSet<Route> Routes { get; set; }

        /// <summary>
        /// Gets or sets database set of <c>Routesteps</c> table
        /// </summary>
        public virtual DbSet<Routestep> Routesteps { get; set; }

        /// <summary>
        /// Gets or sets database set of <c>Routetags</c> table
        /// </summary>
        public virtual DbSet<Routetag> Routetags { get; set; }

        /// <summary>
        /// Gets or sets database set of Steps table
        /// </summary>
        public virtual DbSet<Step> Steps { get; set; }

        /// <summary>
        /// Gets or sets database set of Tags table
        /// </summary>
        public virtual DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets database set of Teams table
        /// </summary>
        public virtual DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets database set of <c>Teamanswers</c> table
        /// </summary>
        public virtual DbSet<Teamanswer> Teamanswers { get; set; }

        /// <summary>
        /// Gets or sets database set of <c>Teamplayers</c> table
        /// </summary>
        public virtual DbSet<Teamplayer> Teamplayers { get; set; }

        /// <summary>
        /// Gets or sets database set of <c>Teamroutes</c> table
        /// </summary>
        public virtual DbSet<Teamroute> Teamroutes { get; set; }

        /// <summary>
        /// Gets or sets database set of Transports table
        /// </summary>
        public virtual DbSet<Transport> Transports { get; set; }

        /// <summary>
        /// Gets or sets database set of Trials table
        /// </summary>
        public virtual DbSet<Trial> Trials { get; set; }

        /// <summary>
        /// Gets or sets database set of Types table
        /// </summary>
        public virtual DbSet<Entities.Type> Types { get; set; }

        /// <summary>
        /// Called when model is created
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("ADMINISTRATOR");

                entity.Property(e => e.Id).HasColumnName("Administrator_Id");

                entity.Property(e => e.Email)
                    .HasColumnName("Administrator_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("Administrator_FirstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Administrator_LastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .HasColumnName("Administrator_Login")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("Administrator_Password")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("ANSWER");

                entity.Property(e => e.Id).HasColumnName("Answer_Id");

                entity.Property(e => e.TrialId).HasColumnName("Answer_fk_Trial_Id");

                entity.Property(e => e.Libelle)
                    .HasColumnName("Answer_Libelle")
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnName("Answer_Picture");

                entity.HasOne(d => d.Trial)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.TrialId)
                    .HasConstraintName("FK_ANSWER_TRIAL");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("GAME");

                entity.Property(e => e.Id).HasColumnName("Game_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("Game_CreationDate")
                    .HasColumnType("date");

                entity.Property(e => e.FinalScore).HasColumnName("Game_FinalScore");

                entity.Property(e => e.FinalTime)
                    .HasColumnName("Game_FinalTime")
                    .HasColumnType("date");

                entity.Property(e => e.OrganizerId).HasColumnName("Game_fk_Organizer_Id");

                entity.Property(e => e.RouteId).HasColumnName("Game_fk_Route_Id");

                entity.Property(e => e.TransportId).HasColumnName("Game_fk_Transport_Id");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK_GAME_ORGANIZER");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_GAME_ROUTE");

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.TransportId)
                    .HasConstraintName("FK_GAME_TRANSPORT");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("MESSAGE");

                entity.Property(e => e.Id)
                    .HasColumnName("Message_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .HasColumnName("Message_Content")
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnName("Message_Date");

                entity.Property(e => e.OrganizerId).HasColumnName("Message_fk_Organizer_Id");

                entity.Property(e => e.PlayerId).HasColumnName("Message_fk_Player_Id");

                entity.Property(e => e.FromOrganiser).HasColumnName("Message_FromOrganiser");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.OrganizerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSAGE_ORGANIZER");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSAGE_PLAYER");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("MISSION");

                entity.Property(e => e.Id).HasColumnName("Mission_Id");

                entity.Property(e => e.Description).HasColumnName("Mission_Description");

                entity.Property(e => e.StepId).HasColumnName("Mission_fk_Step_Id");

                entity.Property(e => e.Name)
                    .HasColumnName("Mission_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Score).HasColumnName("Mission_Score");

                entity.Property(e => e.Time).HasColumnName("Mission_Time");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.StepId)
                    .HasConstraintName("FK_MISSION_STEP");
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.ToTable("ORGANIZER");

                entity.Property(e => e.Id).HasColumnName("Organizer_Id");

                entity.Property(e => e.Email)
                    .HasColumnName("Organizer_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("Organizer_FirstName")
                    .HasMaxLength(50);

                entity.Property(e => e.AdministratorId).HasColumnName("Organizer_fk_Administrator_Id");

                entity.Property(e => e.LastName)
                    .HasColumnName("Organizer_LastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .HasColumnName("Organizer_Login")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("Organizer_Password")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Organizers)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK_ORGANIZER_ADMINISTRATOR");
            });

            modelBuilder.Entity<Play>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.TeamId });

                entity.ToTable("PLAY");

                entity.Property(e => e.GameId).HasColumnName("Play_fk_Game_Id");

                entity.Property(e => e.TeamId).HasColumnName("Play_fk_Team_Id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("Play_EndDate")
                    .HasColumnType("date");

                entity.Property(e => e.Score).HasColumnName("Play_Score");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Play_StartDate")
                    .HasColumnType("date");

                entity.Property(e => e.Time).HasColumnName("Play_Time");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Plays)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLAY_GAME");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Plays)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLAY_TEAM");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("PLAYER");

                entity.Property(e => e.Id).HasColumnName("Player_Id");

                entity.Property(e => e.Email)
                    .HasColumnName("Player_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("Player_FirstName")
                    .HasMaxLength(50);

                entity.Property(e => e.OrganizerId).HasColumnName("Player_fk_Organizer_Id");

                entity.Property(e => e.LastName)
                    .HasColumnName("Player_LastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .HasColumnName("Player_Login")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("Player_Password")
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnName("Player_Picture");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK_PLAYER_ORGANIZER");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("ROUTE");

                entity.Property(e => e.Id).HasColumnName("Route_Id");

                entity.Property(e => e.Description)
                    .HasColumnName("Route_Description")
                    .HasMaxLength(255);

                entity.Property(e => e.Distance)
                    .HasColumnName("Route_Distance")
                    .HasMaxLength(50);

                entity.Property(e => e.OrganizerId).HasColumnName("Route_fk_Organizer_Id");

                entity.Property(e => e.Handicap).HasColumnName("Route_Handicap");

                entity.Property(e => e.Name)
                    .HasColumnName("Route_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnName("Route_Time");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK_ROUTE_ORGANIZER");
            });

            modelBuilder.Entity<Routestep>(entity =>
            {
                entity.HasKey(e => new { e.RouteId, e.StepId });

                entity.ToTable("ROUTESTEP");

                entity.Property(e => e.RouteId).HasColumnName("RouteStep_fk_Route_Id");

                entity.Property(e => e.StepId).HasColumnName("RouteStep_fk_Step_Id");

                entity.Property(e => e.Order).HasColumnName("RouteStep_Order");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Routesteps)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTESTEP_ROUTE");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.Routesteps)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTESTEP_STEP");
            });

            modelBuilder.Entity<Routetag>(entity =>
            {
                entity.HasKey(e => new { e.RouteId, e.TagId })
                    .HasName("PK_STEPTAG");

                entity.ToTable("ROUTETAG");

                entity.Property(e => e.RouteId).HasColumnName("RouteTag_fk_Route_Id");

                entity.Property(e => e.TagId).HasColumnName("RouteTag_fk_Tag_Id");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Routetags)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTETAG_ROUTE");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Routetags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STEPTAG_TAG");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("STEP");

                entity.Property(e => e.Id).HasColumnName("Step_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("Step_CreationDate")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("Step_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.Lat).HasColumnName("Step_Lat");

                entity.Property(e => e.Lng).HasColumnName("Step_Lng");

                entity.Property(e => e.Name)
                    .HasColumnName("Step_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Validation)
                    .HasColumnName("Step_Validation")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("TAG");

                entity.Property(e => e.Id).HasColumnName("Tag_Id");

                entity.Property(e => e.Color)
                    .HasColumnName("Tag_Color")
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasColumnName("Tag_Description");

                entity.Property(e => e.Name)
                    .HasColumnName("Tag_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("TEAM");

                entity.Property(e => e.Id).HasColumnName("Team_Id");

                entity.Property(e => e.CaptainId).HasColumnName("Team_fk_Captain_Id");

                entity.Property(e => e.OrganizerId).HasColumnName("Team_fk_Organizer_Id");

                entity.Property(e => e.Name)
                    .HasColumnName("Team_Name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Captain)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CaptainId)
                    .HasConstraintName("FK_TEAM_PLAYER");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK_TEAM_ORGANIZER");
            });

            modelBuilder.Entity<Teamanswer>(entity =>
            {
                entity.ToTable("TEAMANSWER");

                entity.Property(e => e.Id)
                    .HasColumnName("TeamAnswer_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("TeamAnswer_Date")
                    .HasColumnType("date");

                entity.Property(e => e.AnswerId).HasColumnName("TeamAnswer_fk_Answer_Id");

                entity.Property(e => e.GameId).HasColumnName("TeamAnswer_fk_Game_Id");

                entity.Property(e => e.TeamId).HasColumnName("TeamAnswer_fk_Team_Id");

                entity.Property(e => e.TrialId).HasColumnName("TeamAnswer_fk_Trial_Id");

                entity.Property(e => e.Good).HasColumnName("TeamAnswer_Good");

                entity.Property(e => e.TextAnswer).HasColumnName("TeamAnswer_TextAnswer");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Teamanswers)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMANSWER_ANSWER");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Teamanswers)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMANSWER_GAME");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Teamanswers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMANSWER_TEAM");

                entity.HasOne(d => d.Trial)
                    .WithMany(p => p.Teamanswers)
                    .HasForeignKey(d => d.TrialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMANSWER_TRIAL");
            });

            modelBuilder.Entity<Teamplayer>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.PlayerId })
                    .HasName("PK_TeamPlayer");

                entity.ToTable("TEAMPLAYER");

                entity.Property(e => e.TeamId).HasColumnName("TeamPlayer_fk_Team_Id");

                entity.Property(e => e.PlayerId).HasColumnName("TeamPlayer_fk_Player_Id");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Teamplayers)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMPLAYER_PLAYER");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Teamplayers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMPLAYER_TEAM");
            });

            modelBuilder.Entity<Teamroute>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TEAMROUTE");

                entity.Property(e => e.Id).HasColumnName("TeamRoute_Id");

                entity.Property(e => e.GameId).HasColumnName("TeamRoute_fk_Game_Id");

                entity.Property(e => e.TeamId).HasColumnName("TeamRoute_fk_Team_Id");

                entity.Property(e => e.StepOrder).HasColumnName("TeamRoute_StepOrder");

                entity.Property(e => e.RouteId).HasColumnName("TeamRoute_fk_Route_Id");

                entity.Property(e => e.StepId).HasColumnName("TeamRoute_fk_Step_Id");

                entity.Property(e => e.ValidationDate)
                    .HasColumnName("TeamRoute_ValidationDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Teamroutes)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMROUTE_GAME");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Teamroutes)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAMROUTE_TEAM");

                entity.HasOne(d => d.Routestep)
                    .WithMany(p => p.Teamroutes)
                    .HasForeignKey(d => new { d.RouteId, d.StepId })
                    .HasConstraintName("FK_TEAMROUTE_ROUTESTEP");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("TRANSPORT");

                entity.Property(e => e.Id).HasColumnName("Transport_Id");

                entity.Property(e => e.Description)
                    .HasColumnName("Transport_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.Libelle)
                    .HasColumnName("Transport_Libelle")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Trial>(entity =>
            {
                entity.ToTable("TRIAL");

                entity.Property(e => e.Id).HasColumnName("Trial_Id");

                entity.Property(e => e.CorrectAnswerId).HasColumnName("Trial_fk_CorrectAnswer_Id");

                entity.Property(e => e.MissionId).HasColumnName("Trial_fk_Mission_Id");

                entity.Property(e => e.TypeId).HasColumnName("Trial_fk_Type_Id");

                entity.Property(e => e.Libelle)
                    .HasColumnName("Trial_Libelle")
                    .HasMaxLength(50);

                entity.Property(e => e.Score).HasColumnName("Trial_Score");

                entity.HasOne(d => d.CorrectAnswer)
                    .WithMany(p => p.Trials)
                    .HasForeignKey(d => d.CorrectAnswerId)
                    .HasConstraintName("FK_TRIAL_ANSWER");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Trials)
                    .HasForeignKey(d => d.MissionId)
                    .HasConstraintName("FK_TRIAL_MISSION");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Trials)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TRIAL_TYPE");
            });

            modelBuilder.Entity<Entities.Type>(entity =>
            {
                entity.ToTable("TYPE");

                entity.Property(e => e.Id).HasColumnName("Type_Id");

                entity.Property(e => e.Description).HasColumnName("Type_Description");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// OnModelCreatingPartial with ModelBuilder
        /// </summary>
        /// <param name="modelBuilder">Model Builder</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
