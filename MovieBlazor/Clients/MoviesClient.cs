﻿using MovieBlazor.Models;

namespace MovieBlazor.Clients
{
    public class MoviesClient(HttpClient httpClient)
    {
        public async Task<Movie[]> GetMoviesAsync() => await httpClient.GetFromJsonAsync<Movie[]>("movies") ?? [];

        // get the movie by id
        public async Task<Movie> GetMovieByIdAsync(int id) => await httpClient.GetFromJsonAsync<Movie>($"movies/{id}") ?? throw new Exception("Could not find movie");

        // add a new movie
        public async Task AddMovieAsync(Movie movie) => await httpClient.PostAsJsonAsync("movies", movie);
    }
}
