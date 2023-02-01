export interface UserInfo {
  username: string;
  birthday: string;
  email: string;
  aboutInfo: string;
  numberOfPublications: number | null;
  isOldUser: boolean;
  roleName: string;
  errorMessage: string | null;
}
