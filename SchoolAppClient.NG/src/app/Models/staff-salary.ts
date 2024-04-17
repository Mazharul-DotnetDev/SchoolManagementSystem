export class StaffSalary {
  // Per individual Staff's salary prototype
  staffSalaryId!: number;
  basicSalary?: number;
  festivalBonus?: number;
  allowance?: number;
  medicalAllowance?: number;
  housingAllowance?: number;
  transportationAllowance?: number;
  savingFund: number = 0;
  taxes: number = 0;
  netSalary?: number; // Add NetSalary property to be stored in the database; Related to CalculateNetSalary() method

  constructor() {
    this.savingFund = 0;
    this.taxes = 0;
  }

  // Method to calculate net salary
  calculateNetSalary(): void {
    this.netSalary = (this.basicSalary ?? 0) +
      (this.festivalBonus ?? 0) +
      (this.allowance ?? 0) +
      (this.medicalAllowance ?? 0) +
      (this.housingAllowance ?? 0) +
      (this.transportationAllowance ?? 0) -
      this.savingFund - this.taxes;
  }
}
