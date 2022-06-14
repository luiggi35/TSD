import React from "react";
import { NavLink } from "react-router-dom";
import styles from "./styles.module.css";


function Home() {
  return (
    <div className={styles.container}>
            <h3>Home Page</h3>
            <div className={styles.nav_link_container}>
                <NavLink className="nav-link" to={`/counter`} >
                    -- Counter --
                </NavLink>
                <NavLink className="nav-link" to={`/tic-tac-toe`} >
                    -- Tic Tac Toe --
                </NavLink>
            </div>


        </div>
  );
}

export default Home;