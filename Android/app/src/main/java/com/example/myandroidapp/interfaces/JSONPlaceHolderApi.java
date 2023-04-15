package com.example.myandroidapp.interfaces;

import com.example.myandroidapp.classes.Post;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface JSONPlaceHolderApi {
    @GET("/api/Categories/list")
    public Call <List<Post>> getCategories();
}
