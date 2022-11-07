import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Vending } from "./components/Vending";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/vending',
    element: <Vending />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
