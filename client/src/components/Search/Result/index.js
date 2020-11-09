import React from 'react';
import { useSelector } from 'react-redux';

import Loader from '../../Loader';
import { Box } from './styled';

const generateResults = (resultItems) => {
    if (resultItems.length === 0) {
        return <Box>The link is not found in the search results</Box>;
    }

    return (
        <Box>
            The requested link is found on positions below:
            <br />
            <br />
            {resultItems.map(ri => ri.position).join(", ")}
        </Box>
    );
};

const Result = (props) => {
    const isLoading = useSelector(state => state.search.isLoading);
    const searchResult = useSelector(state => state.search.searchResult);
    const error = useSelector(state => state.search.error);

    console.log(isLoading);

    if (isLoading) {
        return <Loader/>;
    }

    if (error !== null) {
        return <Box>Error in loading results. Please check the parameters and try again.</Box>;
    }

    if (searchResult == null) {
        return <Box>Please enter the parameters and click on the search button.</Box>;
    }

    return generateResults(searchResult.resultItems);
}

export default Result;