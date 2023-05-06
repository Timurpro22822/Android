package com.example.myandroidapp.network;

import com.example.myandroidapp.dto.account.RegisterDTO;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface AccountApi {
    @POST("/api/account/register")
    public Call<Void> register(@Body RegisterDTO registerDTO);

}
