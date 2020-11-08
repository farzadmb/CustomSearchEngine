import React from 'react';

const Result = (props) => {
    const { status, error } = props;

    if (error !== null) {
        return (
            <div>Error in loading results. Please check the parameters and try again.</div>
        );
    }

    if (status == null) {
        return (
            <div>Please enter the parameters and click on the search button.</div>
        );
    }

    const { positions } = status;

    if (positions.length === 0) {
        return (
            <div>The link is not found in the search results</div>
        );
    }

    return (
        <div>
            The requested link is found on positions below: {positions.join(", ")}
        </div>
    );
}

export default Result;