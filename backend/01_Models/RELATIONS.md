# Model Relationships

This document describes the relationships between the models in the CameraClub2 backend.

- **User**
  - Has many `ClubMemberships`, `Equipment`, `Comments`, `Uploads` (Images), and `JudgingAssignments`.
- **Club**
  - Has many `Competitions` and `Members` (ClubMemberships).
- **ClubMembership**
  - Belongs to one `Club` and one `User`.
- **Competition**
  - Belongs to one `Club`.
  - Has many `Submissions` and `JudgingAssignments`.
- **Image**
  - Belongs to one `User` (Uploader).
  - Has many `Submissions`, `Comments`, and `Ratings`.
- **Submission**
  - Belongs to one `Competition` and one `Image`.
  - Has many `Ratings` and `Comments`.
- **Rating**
  - Belongs to one `Submission` and one `User` (Judge).
- **Comment**
  - Belongs to one `Submission` and one `User`.
- **JudgingAssignment**
  - Belongs to one `Competition` and one `User` (Judge).
- **Equipment**
  - Belongs to one `User`.
