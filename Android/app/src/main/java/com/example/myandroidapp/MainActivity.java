package com.example.myandroidapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.example.myandroidapp.classes.NetworkService;
import com.example.myandroidapp.classes.Post;


import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends BaseActivity {
//    TextView categoryName;
    ListView categoryListView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        categoryListView = findViewById(R.id.categoryListView);
        NetworkService.getInstance()
                .getJSONApi()
                .getCategories()
                .enqueue((new Callback<List<Post>>() {
                    @Override
                    public void onResponse(Call<List<Post>> call, Response<List<Post>> response) {
                        List<Post> posts = response.body();
                        List<String> data = new ArrayList<>();
//                        for (Post item:posts
//                             ) {
//                            categoryName.append((item.getName()+"\n"));
//                            categoryListView.append(item.getName()+"\n");
//                            categoryListView.append(item.getImage()+"\n");
//                        }
                        for (Post item : posts) {
                            data.add(item.getName() + "\n" + item.getImage() + "\n");
                        }
                        ArrayAdapter<String> adapter = new ArrayAdapter<>(MainActivity.this, android.R.layout.simple_list_item_1, data);
                        categoryListView.setAdapter(adapter);
                    }

                    @Override
                    public void onFailure(Call<List<Post>> call, Throwable t) {
                        //textView.append("Error occurred while getting request!");
                        t.printStackTrace();
                    }
                }));
    }
}