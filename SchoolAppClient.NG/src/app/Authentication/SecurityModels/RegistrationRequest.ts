export class RegistrationRequest {
  email: string = '';
  username: string = '';
  password: string = '';
  role?: string[] = []; // Assuming role is optional and an array of strings
}
