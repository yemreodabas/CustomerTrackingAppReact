export const appGlobalStore = createStore({
    auth: {
        currentUser: {id: 0, username: "Visitor"},
        add: action((state, payload) => {
            state.currentUser = payload;
        })
    }
});