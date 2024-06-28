Here's an example of a Python Flask API code that implements the given user story:

```python
from flask import Flask, request, jsonify

app = Flask(__name__)

@app.route('/credit-check', methods=['POST'])
def credit_check():
    # Get applicant's credit score and financial history from the request
    credit_score = request.json['credit_score']
    financial_history = request.json['financial_history']

    # Perform credit check logic here
    # ...

    # Return credit check result
    return jsonify({'credit_check_result': 'pass'})

@app.route('/pre-qualification', methods=['POST'])
def pre_qualification():
    # Get applicant's debt-to-income ratio from the request
    debt_to_income_ratio = request.json['debt_to_income_ratio']

    # Perform pre-qualification logic here
    # ...

    # Calculate maximum loan amount and interest rate range
    max_loan_amount = 100000  # Example value, replace with actual calculation
    interest_rate_range = (3.5, 5.0)  # Example value, replace with actual calculation

    # Return pre-qualification result
    return jsonify({
        'max_loan_amount': max_loan_amount,
        'interest_rate_range': interest_rate_range
    })

@app.route('/update-status', methods=['PUT'])
def update_status():
    # Get applicant's ID and pre-qualification status from the request
    applicant_id = request.json['applicant_id']
    pre_qualification_status = request.json['pre_qualification_status']

    # Update pre-qualification status in the system
    # ...

    # Return success message
    return jsonify({'message': 'Pre-qualification status updated successfully'})

if __name__ == '__main__':
    app.run(debug=True)
```

This code defines three routes: `/credit-check`, `/pre-qualification`, and `/update-status`. The `/credit-check` route accepts a POST request with the applicant's credit score and financial history, performs the credit check logic, and returns the credit check result. The `/pre-qualification` route accepts a POST request with the applicant's debt-to-income ratio, performs the pre-qualification logic, calculates the maximum loan amount and interest rate range, and returns the pre-qualification result. The `/update-status` route accepts a PUT request with the applicant's ID and pre-qualification status, updates the pre-qualification status in the system, and returns a success message.