import { Route, Routes } from "react-router-dom";
import Home from "./Components/Home.jsx"
import Counter from "./Components/Counter"
import TicTacToe from "./Components/TicTacToe"

function App() {
  return (
    <div className="App">
      <Routes>
            <Route path="/" exact element={<Home />} />
            <Route path="/counter" exact element={<Counter />} />
            <Route path="/tic-tac-toe" exact element={<TicTacToe />} />
        </Routes>
      
    </div>
  );
}

export default App;
