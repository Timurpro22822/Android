package com.example.myandroidapp.category;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;
import com.example.myandroidapp.R;
import com.example.myandroidapp.application.HomeApplication;
import com.example.myandroidapp.classes.Post;
import com.example.myandroidapp.constants.Urls;


import java.util.List;

public class CategoriesAdapter extends RecyclerView.Adapter<CategoryCardViewHolder> {

    private List<Post> categories;

    public CategoriesAdapter(List<Post> categories) {
        this.categories = categories;
    }

    @NonNull
    @Override
    public CategoryCardViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater
                .from(parent.getContext())
                .inflate(R.layout.category_view, parent, false);
        return new CategoryCardViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull CategoryCardViewHolder holder, int position) {
        if(categories!=null && position<categories.size())
        {
            Post item = categories.get(position);
            holder.getCategoryName().setText(item.getName());
            String url = Urls.BASE+item.getImage();
            Glide.with(HomeApplication.getAppContext())
                    .load(url)
                    .apply(new RequestOptions().override(600))
                    .into(holder.getCategoryImage());
        }
    }

    @Override
    public int getItemCount() {
        return categories.size();
    }
}