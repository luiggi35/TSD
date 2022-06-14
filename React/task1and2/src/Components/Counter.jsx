import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import styles from "./styles.module.css";


function Counter() {

    var [counter, setCounter] = useState(0)


    const handleClickPlus = () => {
        
        setCounter(counter + 1)
        if (counter + 1 < 0) {
            document.getElementById("counter").style.color = "red"
        } else if (counter + 1 > 0 ) {
            document.getElementById("counter").style.color = "green"
        } else {
            document.getElementById("counter").style.color = "black"
        }
    }

    const handleClickUnder = () => {
        
        
        setCounter(counter - 1)
        if (counter - 1 < 0) {
            document.getElementById("counter").style.color = "red"
        } else if (counter - 1 > 0 ) {
            document.getElementById("counter").style.color = "green"
        } else {
            document.getElementById("counter").style.color = "black"
        }
    }

    return (
        <div className={styles.container}>
            <h3>Counter Page</h3>
            <div className={styles.nav_link_container}>
                <NavLink className="nav-link" to={`/`} >
                    -- Home --
                </NavLink>
                <NavLink className="nav-link" to={`/tic-tac-toe`} >
                    -- Tic Tac Toe --
                </NavLink>
            </div>
            <div className={styles.counter}>
                <h3 id="counter">{counter}</h3>
                <button onClick={handleClickPlus} style={{margin: 10 }}>+</button>
                <button onClick={handleClickUnder} style={{margin: 10 }}>-</button>
            </div>


        </div>
    );
}

export default Counter;