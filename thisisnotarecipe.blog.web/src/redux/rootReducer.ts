import { combineReducers } from "redux";

const fakeReducer = (state: any, action: any) => ({ ...state });

export default combineReducers({ fakeReducer });
