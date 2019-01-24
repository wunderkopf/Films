export interface Film {
    id: number;
    title: string;
    genres: number[];
    // does not come from server
    genresTitles: Array<[number, string]>;
}