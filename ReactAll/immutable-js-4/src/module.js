import { createStore } from "redux";
import { fromJS } from "immutable";

const initialState = fromJS({
  data: { potentially: { deep: "data" } }
});

const CONSTANTS = {
  setData: "SET_DATA"
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case CONSTANTS.setData:
      return state.setIn(["data", "potentially", "deep"], action.payload.data);
    default:
      return state;
  }
};

export const setData = newData => ({
  type: CONSTANTS.setData,
  payload: { data: newData }
});

export const getData = state => state.getIn(["data", "potentially", "deep"]);

export const store = createStore(reducer);