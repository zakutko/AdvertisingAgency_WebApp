export interface UserInfo {
    username: string;
    age: number;
    email: string;
    aboutInfo: string;
    numberOfPublications: number | null;
    isOldUser: boolean | null;
    roleName: string;
    errorMessage: string | null;
}