package com.example.myandroidapp.network;

import com.example.myandroidapp.dto.category.CategoryCreateDTO;
import com.example.myandroidapp.dto.category.CategoryItemDTO;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface CategoriesApi {
    @GET("/api/categories/list")
    public Call<List<CategoryItemDTO>> list();
    @GET("/api/categories/{id}")
    public Call<CategoryItemDTO> get(@Path("id")int id);
    @DELETE("/api/categories/{id}")
    public Call<Void> delete(@Path("id")int id);
    @POST("/api/categories/create")
    public Call<Void> create(@Body CategoryCreateDTO model);
}