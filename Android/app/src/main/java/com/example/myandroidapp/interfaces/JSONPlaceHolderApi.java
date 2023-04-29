package com.example.myandroidapp.interfaces;

import com.example.myandroidapp.classes.CategoryCreateDTO;
import com.example.myandroidapp.classes.Post;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface JSONPlaceHolderApi {
    @GET("/api/Categories/list")
    public Call <List<Post>> getCategories();
    @POST("/api/Categories/create")
    public Call<Void> postCategories(@Body CategoryCreateDTO model);
}
