export interface Advertisement{
    userId: string;
    bannerId: string;
    username: string;
    title: string;
    subTitle: string;
    description: string;
    linkToBrowserPage: string;
    releaseDate: Date;
    status: string;
    photoUrl: string;
    comment: string | null;
};