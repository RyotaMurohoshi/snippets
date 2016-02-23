package com.muhron.anko_example

import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import org.jetbrains.anko.*

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        async() {
            Thread.sleep(10000L)

            uiThread {
                toast("Hello")
            }
        }
    }
}
