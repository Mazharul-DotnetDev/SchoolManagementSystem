export class StaffExperience {
  staffExperienceId!: number;
  companyName?: string;
  designation?: string;
  joiningDate: Date = new Date();
  leavingDate?: Date = new Date();
  responsibilities?: string;
  achievements?: string;
  serviceDuration: string | null = null;

  constructor() {
    this.joiningDate = new Date();
    this.leavingDate = new Date();
  }

  // Method to calculate service duration
  calculateServiceDuration(): void {
    if (this.leavingDate) {
      const durationMs = new Date(this.leavingDate).getTime() - new Date(this.joiningDate).getTime();
      const years = Math.floor(durationMs / (1000 * 60 * 60 * 24 * 365));
      const months = Math.floor((durationMs % (1000 * 60 * 60 * 24 * 365)) / (1000 * 60 * 60 * 24 * 30));
      this.serviceDuration = `${years} years, ${months} months`;
    } else {
      const durationMs = new Date().getTime() - new Date(this.joiningDate).getTime();
      const years = Math.floor(durationMs / (1000 * 60 * 60 * 24 * 365));
      const months = Math.floor((durationMs % (1000 * 60 * 60 * 24 * 365)) / (1000 * 60 * 60 * 24 * 30));
      this.serviceDuration = `${years} years, ${months} months`;
    }
  }
}
