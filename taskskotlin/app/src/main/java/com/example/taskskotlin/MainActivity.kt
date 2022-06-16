package com.example.taskskotlin

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.Toast

class MainActivity : AppCompatActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val btn_click_me = findViewById(R.id.buttonHW) as Button
        // set on-click listener
        btn_click_me.setOnClickListener {
            Toast.makeText(this@MainActivity, "Hello World", Toast.LENGTH_SHORT).show()
        }
    }



}