#!/bin/bash

echo "Running shell script...."

option="${1}"

if [ "${option}" == "" ]; then
	echo "TestScript.sh : Usage : [ 0-9 operations ]"
	echo "0 : Do Nothing - Exit"
	echo "1 : openssl dgst"
	echo "2 : xxd"
	echo "3 : openssl x509"
	echo "4 : Extract Pub Key"
	echo "5 : Signature Verify"
	exit
fi

if [ "${option}" != "" ]; then	
	case "${option}" in
		0) 
			
			;;

		1) 
			in_filename="${2}"
			out_filename="${3}"
			#openssl dgst -sha256 WPCCA1.cer
			openssl dgst -sha256 "${in_filename}" > "${out_filename}"
			#openssl dgst -sha256 WPCCA2.txt > hashinit.txt
			;;

		2) 
			openssl rand -hex 16 -out n.txt
			;;

		3) 
			in_filename="${2}"
			out_filename="${3}"
			cert_filename="${4}"
			openssl x509 -inform der -in "${in_filename}" -out "${out_filename}"
			#openssl x509 -in "${out_filename}" -text -noout | tee "${cert_filename}"
			openssl x509 -in "${out_filename}" -text -noout > "${cert_filename}"
			;;

		4)
			in_filename="${2}"
			out_filename="${3}"
			openssl x509 -pubkey -noout -in "${in_filename}"  > "${out_filename}"
			;;

		5)
			in_filename="${2}"
			in1_filename="${3}"
			out_filename="${4}"
			openssl dgst -sha256 -verify "${in_filename}" -signature "${in1_filename}" "${out_filename}" 
			;;
		6)
			openssl x509 -pubkey -noout -in p.pem | openssl enc -base64 -d > pubkey.der
			hexdump -e '100/1 "%02x" "\n"' pubkey.der > test_PublicKey.txt
			;;
		7)
			in_filename="${2}"
			in1_filename="${3}"
			out_filename="${4}"
			openssl dgst -sha256 -verify "${in_filename}" -keyform DER -signature "${in1_filename}" "${out_filename}" 
			;;
		8)
			openssl rand -hex 32 -out n.txt
			;;
	esac
fi
			
		
